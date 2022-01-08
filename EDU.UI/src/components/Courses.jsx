import React from "react";
import { List, Button, Space, Avatar } from "antd";
import {
  MessageOutlined,
  LikeOutlined,
  StarOutlined,
  CodepenOutlined,
  CodeSandboxOutlined,
  CodeOutlined,
} from "@ant-design/icons";
import EDUContext from "../contexts/EDU.Context";
import { getRandomNumber } from "../services";

const IconText = ({ icon, text }) => (
  <Space>
    {React.createElement(icon)}
    {text}
  </Space>
);

const randomNumberString = () => getRandomNumber().toString();

const imgs = [
  () => <CodeSandboxOutlined />,
  () => <CodepenOutlined />,
  () => <CodeOutlined />,
];

const Courses = () => {
  const [state] = React.useContext(EDUContext);

  const dataSource = state.courses.map(x => ({
    ...x,
    img: imgs[getRandomNumber(0, 2)],
  }));

  return (
    <div className="container">
      <Button type="primary">Add Course</Button>
      <List
        itemLayout="vertical"
        size="large"
        pagination={{ pageSize: 20 }}
        dataSource={dataSource}
        renderItem={item => (
          <List.Item
            key={item.title}
            actions={[
              <IconText
                icon={StarOutlined}
                text={randomNumberString()}
                key="list-vertical-star-o"
              />,
              <IconText
                icon={LikeOutlined}
                text={randomNumberString()}
                key="list-vertical-like-o"
              />,
              <IconText
                icon={MessageOutlined}
                text={randomNumberString()}
                key="list-vertical-message"
              />,
            ]}
            extra={<div style={{ fontSize: 50 }}>{item.img()}</div>}
          >
            <List.Item.Meta
              avatar={<Avatar src={item.avatar} />}
              title={<a href={item.href}>{item.title}</a>}
              description={item.description}
            />
            {item.content}
          </List.Item>
        )}
      />
    </div>
  );
};

export default Courses;
