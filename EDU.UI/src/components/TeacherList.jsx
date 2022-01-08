import React from "react";
import { List, Skeleton } from "antd";
import EDUContext from "../contexts/EDU.Context";
import { getAllUsers } from "../services";

const TeacherList = () => {
  const [loading, setLoading] = React.useState(false);
  const [state, setState] = React.useContext(EDUContext);

  React.useEffect(() => {
    setLoading(true);
    getAllUsers(setState).then(() => setLoading(false));
  }, []);

  const renderItem = item => (
    <List.Item key={item.id}>
      <Skeleton loading={loading} title={false} active>
        <div>
          <List.Item.Meta title={item?.email} />
          {`${item?.username} ${item?.phone}`}
        </div>
      </Skeleton>
    </List.Item>
  );

  return (
    <div className="container">
      <h1>Teacher List</h1>
      <List
        loading={loading}
        itemLayout="horizontal"
        pagination={{ pageSize: 20 }}
        dataSource={state.users
          .filter(x => x.roles.includes("Teacher"))
          .sort((a, b) => b.username < a.username)}
        renderItem={renderItem}
      />
    </div>
  );
};

export default TeacherList;
