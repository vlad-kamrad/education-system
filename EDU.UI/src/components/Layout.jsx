import React from "react";
import { Link, useLocation } from "react-router-dom";

import { Layout, Menu } from "antd";

const AppLayout = props => {
  const [selectedIndex, setSelectedIndex] = React.useState("1");

  const location = useLocation().pathname;

  return (
    <Layout>
      <Layout.Header>
        <div className="logo">DNU DECM</div>
        <Menu
          theme="dark"
          mode="horizontal"
          defaultSelectedKeys={[location]}
          onSelect={info => setSelectedIndex(info.key)}
        >
          <Menu.Item key="/user-list">
            <Link to={"/user-list"}>Users</Link>
          </Menu.Item>
          <Menu.Item key="/group-list">
            <Link to={"/group-list"}>Groups</Link>
          </Menu.Item>
          <Menu.Item key="/teacher-list">
            <Link to={"/teacher-list"}>Teachers</Link>
          </Menu.Item>
          <Menu.Item key="/courses-list">
            <Link to={"/courses-list"}>Courses</Link>
          </Menu.Item>
          <Menu.Item key="/complaints-suggestions">
            <Link to={"/complaints-suggestions"}>
              Complaints and suggestions
            </Link>
          </Menu.Item>
        </Menu>
      </Layout.Header>
      <Layout.Content style={{ marginTop: 25 }}>
        {props.children}
      </Layout.Content>
      <Layout.Footer style={{ textAlign: "center" }}>
        DNU DECM ©2022 Created by Students
      </Layout.Footer>
    </Layout>
  );
};

export default AppLayout;
