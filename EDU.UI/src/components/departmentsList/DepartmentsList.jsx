import React, { useState, useEffect, useContext } from "react";
import { List, Skeleton } from "antd";
import Auth from "../../utils/Auth";
import redirectTo from "../../utils/redirectTo";
import { BASE_URL, API_ENDPOINTS } from "../../constants/index";
import HttpRequest from "../../utils/HttpRequest";
import EDUContext from "../../contexts/EDU.Context";

const getDepartmentsUrl = BASE_URL + API_ENDPOINTS.departments;

const DepartmentsList = () => {
  const [loading, setLoading] = useState(false);
  const [state, setState] = useContext(EDUContext);

  useEffect(() => {
    !Auth.isSignedIn() && redirectTo.login();
  }, []);

  useEffect(() => {
    setLoading(true);
    (async () => {
      await HttpRequest.get(getDepartmentsUrl).then(({ departments }) => {
        if (departments?.length)
          setState(p => ({ ...p, departments: [...departments] }));
        setLoading(false);
      });
    })();
  }, []);

  const renderItem = item => (
    <List.Item key={item.id}>
      <Skeleton loading={loading} title={false} active>
        <div>
          <List.Item.Meta title={item.id} />
          {`${item.name} - ${item.head}`}
        </div>
      </Skeleton>
    </List.Item>
  );

  return (
    <div className="body">
      <List
        loading={loading}
        itemLayout="horizontal"
        pagination={{ pageSize: 5 }}
        dataSource={state?.departments?.sort((a, b) => b.id - a.id)}
        renderItem={renderItem}
      />
    </div>
  );
};

export default DepartmentsList;
