import React from "react";
import { Button, Checkbox, Form, Input, Select, Modal, List } from "antd";
import EDUContext from "../contexts/EDU.Context";
import { createCS, getCurrentUserId } from "../services";

const { TextArea } = Input;

const ComplaintsSuggestions = props => {
  const [state, setState] = React.useContext(EDUContext);
  const [isShowViewAllCS, ssvacs] = React.useState(false);
  const [form] = Form.useForm();

  const onFinish = values => {
    const { type, text, isAnonymously } = values;
    const creatorId = isAnonymously ? null : getCurrentUserId();
    const body = { text, type, creatorId };

    createCS(body, state, id =>
      setState(p => ({ ...p, compSugg: [...p.compSugg, { ...body, id: id }] }))
    );
  };

  return (
    <div className="container">
      <div
        className="centered"
        style={{
          width: "50vw",
          transform: "translateX(12.5vw)",
        }}
      >
        <Form
          {...layout}
          form={form}
          onFinish={onFinish}
          fields={[
            { name: ["type"], value: "suggestions" },
            { name: ["isAnonymously"], value: false },
          ]}
        >
          <Form.Item label="Type" name="type" rules={[{ required: true }]}>
            <Select placeholder="Select Type" onChange={() => {}}>
              <Select.Option key={1} value="complaints">
                {"Complaints"}
              </Select.Option>
              <Select.Option key={2} value="suggestions">
                {"Suggestions"}
              </Select.Option>
            </Select>
          </Form.Item>
          <Form.Item label="Anonymously" name="isAnonymously">
            <Checkbox />
          </Form.Item>
          <Form.Item label="Text" name="text">
            <TextArea showCount maxLength={1000} />
          </Form.Item>
          <Form.Item {...tailLayout}>
            <Button type="primary" htmlType="submit">
              {"Send"}
            </Button>
            <Button htmlType="button" onClick={() => ssvacs(true)}>
              {"View All Complaints & Suggestions"}
            </Button>
          </Form.Item>
        </Form>
        <AllComplaintsSuggestions
          isShow={isShowViewAllCS}
          onClose={() => ssvacs(false)}
        />
      </div>
    </div>
  );
};

function AllComplaintsSuggestions({ onClose, isShow }) {
  const [state] = React.useContext(EDUContext);
  return (
    <Modal
      title="All Complaints Suggestions"
      visible={isShow}
      onCancel={onClose}
      className="view-all-cs-modal"
      width={"auto"}
    >
      <List
        pagination={{ pageSize: 20 }}
        dataSource={state.compSugg}
        itemLayout="horizontal"
        renderItem={item => {
          const { id, type, text, creatorId } = item;
          return (
            <List.Item
              key={id}
              actions={[<Button onClick={() => {}}>More Info</Button>]}
            >
              <div>
                <List.Item.Meta
                  title={type}
                  description={
                    creatorId === null
                      ? "Anonymous"
                      : state.users[creatorId].username
                  }
                />
                {text}
              </div>
            </List.Item>
          );
        }}
      />
    </Modal>
  );
}

export default ComplaintsSuggestions;

var layout = { labelCol: { span: 8 }, wrapperCol: { span: 16 } };
var tailLayout = { wrapperCol: { offset: 8, span: 18 } };
