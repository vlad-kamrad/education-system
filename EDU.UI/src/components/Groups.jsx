import React from "react";
import { List, Skeleton, Button, Modal, Form, Input, Select } from "antd";
import EDUContext from "../contexts/EDU.Context";
import { getAllGroups, createGroup } from "../services";

const Groups = props => {
  const [loading, setLoading] = React.useState(false);
  const [state, setState] = React.useContext(EDUContext);
  const [isShowCreateGroupModal, scgm] = React.useState(false);
  const [selectedGroup, selectGroup] = React.useState(null);

  React.useEffect(() => {
    setLoading(true);
    getAllGroups(setState).then(() => setLoading(false));
  }, []);

  const renderItem = item => {
    const curatorName = state.users.find(
      x => item.curator.id === x.id
    ).username;

    return (
      <List.Item
        key={item.id}
        onClick={() => {}}
        actions={[<Button onClick={() => selectGroup(item)}>View</Button>]}
      >
        <Skeleton loading={loading} title={true} active>
          <div>
            <List.Item.Meta title={item?.title} />
            {`Curator: ${curatorName}`}
          </div>
        </Skeleton>
      </List.Item>
    );
  };

  return (
    <div className="container">
      <h1>Group List</h1>
      <Button type="primary" onClick={() => scgm(true)}>
        Create New Group
      </Button>
      <List
        loading={loading}
        itemLayout="horizontal"
        pagination={{ pageSize: 5 }}
        dataSource={state?.groups?.sort?.((a, b) => b?.id - a?.id)}
        renderItem={renderItem}
      />
      <CreateGroupModal
        onCancel={() => scgm(false)}
        isShow={isShowCreateGroupModal}
      />
      <ViewGroupModal
        onCancel={() => selectGroup(null)}
        isShow={!!selectedGroup}
        selectedGroup={selectedGroup}
      />
    </div>
  );
};

function ViewGroupModal(props) {
  const [state, setState] = React.useContext(EDUContext);
  const [form] = Form.useForm();

  const { isShow, onCancel, selectedGroup } = props;

  if (!selectedGroup) return null;

  const groupId = selectedGroup.id;
  const groupTitle = selectedGroup.title;
  const groupCurator = state.users.find(x => selectedGroup.curator.id === x.id);

  console.log({ props });

  const onReset = () => form.resetFields();

  const onFinish = values => {
    const { title, curator } = values;
    const body = {
      title,
      curator: { id: curator },
      head: {},
    };
  };

  return (
    <Modal
      title="View Group"
      visible={isShow}
      onCancel={() => {
        onReset();
        onCancel();
      }}
      className="view-group-modal"
    >
      <Form
        {...viewLayout}
        form={form}
        onFinish={onFinish}
        fields={[
          { name: ["title"], value: groupTitle },
          { name: ["curator"], value: groupCurator.id },
        ]}
      >
        <Form.Item label="Title" name="title" rules={[{ required: true }]}>
          <Input readOnly />
        </Form.Item>
        <Form.Item label="Curator" name="curator" rules={[{ required: true }]}>
          <Select
            placeholder="Select Curator person"
            onChange={() => {}}
            allowClear
          >
            {state.users
              .filter(x => x.roles.includes("Teacher"))
              .map((x, i) => (
                <Select.Option key={i} value={x.id}>
                  {x.username}
                </Select.Option>
              ))}
          </Select>
        </Form.Item>
      </Form>

      <Button type="primary">Add Student</Button>
      <List
        itemLayout="horizontal"
        pagination={{ pageSize: 40 }}
        dataSource={state?.students
          ?.filter(x => x.groupId === groupId)
          .map(x => {
            x.name = state.users.find(z => z.id === x.userId).username;
            return x;
          })
          .sort(function (a, b) {
            if (a.name > b.name) return 1;
            if (a.name < b.name) return -1;
            return 0;
          })}
        renderItem={item => {
          const student = state.users.find(x => item.userId === x.id);

          return (
            <List.Item
              key={student.id}
              actions={[<Button onClick={() => {}}>Details</Button>]}
            >
              <div>
                <List.Item.Meta title={item?.title} />
                {student.username}
              </div>
            </List.Item>
          );
        }}
      />
    </Modal>
  );
}

function CreateGroupModal(props) {
  const [state, setState] = React.useContext(EDUContext);
  const { isShow, onCancel } = props;
  const [form] = Form.useForm();

  const onReset = () => form.resetFields();
  const onFinish = values => {
    const { title, curator } = values;
    const body = {
      title,
      curator: { id: curator },
      head: {},
    };

    createGroup(body, state, id =>
      setState(p => ({ ...p, groups: [...p.groups, { ...body, id: id }] }))
    );
  };

  return (
    <Modal
      title="Create Group"
      visible={isShow}
      okText="Create"
      onOk={() => {}}
      onCancel={() => {
        onReset();
        onCancel();
      }}
    >
      <Form {...layout} form={form} onFinish={onFinish}>
        <Form.Item label="Title" name="title" rules={[{ required: true }]}>
          <Input />
        </Form.Item>
        <Form.Item label="Curator" name="curator" rules={[{ required: true }]}>
          <Select
            placeholder="Select Curator person"
            onChange={() => {}}
            allowClear
          >
            {state.users
              .filter(x => x.roles.includes("Teacher"))
              .map((x, i) => (
                <Select.Option key={i} value={x.id}>
                  {x.username}
                </Select.Option>
              ))}
          </Select>
        </Form.Item>
        <Form.Item {...tailLayout}>
          <Button type="primary" htmlType="submit">
            Create
          </Button>
          <Button htmlType="button" onClick={onReset}>
            Reset
          </Button>
        </Form.Item>
      </Form>
    </Modal>
  );
}

var layout = { labelCol: { span: 8 }, wrapperCol: { span: 16 } };
var tailLayout = { wrapperCol: { offset: 8, span: 16 } };
var viewLayout = { labelCol: { span: 2 }, wrapperCol: { span: 8 } };

export default Groups;
