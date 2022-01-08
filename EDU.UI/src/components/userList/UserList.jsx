import React, { useState, useEffect, useContext } from "react";
import { List, Skeleton, Button, Popover, Checkbox, notification } from "antd";
import { MESSAGES } from "../../constants/index";
import EDUContext from "../../contexts/EDU.Context";
import { getAllUsers, changeRoles } from "../../services";

const UserList = () => {
  const [loading, setLoading] = useState(false);
  const [state, setState] = useContext(EDUContext);
  const [{ editedUser, desRoles }, setEditedUser] = useState({ desRoles: [] });

  useEffect(() => {
    setLoading(true);
    getAllUsers(setState).then(() => setLoading(false));
  }, []);

  const showSuccesEdited = () => {
    notification["success"]({
      message: MESSAGES.SUCCESS,
      description: MESSAGES.SUCCESS_CREATED_TEXT,
      placement: "bottomLeft",
    });
  };

  const onClickChangeRoles = userId => {
    const body = { userId, DesiredRoles: desRoles };

    changeRoles(body, () => {
      const usrs = state.users.map(x => {
        if (x.id === userId) {
          x.roles = desRoles;
          return x;
        }
        return x;
      });
      setState(p => ({ ...p, users: usrs }));
      showSuccesEdited();
    });
  };

  const renderUserRolesBlock = userId => {
    const { roles } = state.users.filter(x => x.id === userId)[0];
    const allRoles = state.roles;
    return (
      <div className="chbxs">
        {allRoles.map((role, i) => {
          const isUsedUser = roles.some(d => d === role);
          return (
            <div key={`chbx-${i}`}>
              <Checkbox
                defaultChecked={isUsedUser}
                onChange={() => {
                  if (!editedUser || editedUser !== userId) {
                    setEditedUser(p => ({
                      ...p,
                      editedUser: userId,
                      desRoles: roles,
                    }));
                  }

                  const isCheck = desRoles.some(rol => rol === role);
                  const nRoles = isCheck
                    ? desRoles.filter(x => x !== role)
                    : [...desRoles, role];
                  setEditedUser(p => ({ ...p, desRoles: nRoles }));
                }}
              >
                {role}
              </Checkbox>
            </div>
          );
        })}
        <Button onClick={() => onClickChangeRoles(userId)}>Save Changes</Button>
      </div>
    );
  };

  const renderItem = item => (
    <List.Item
      key={item.id}
      onClick={() => {}}
      actions={[
        <Popover
          placement="left"
          title={"Title"}
          content={renderUserRolesBlock(item.id)}
          trigger="click"
          destroyTooltipOnHide={true}
        >
          <Button
            onClick={() => {
              setEditedUser(p => ({
                ...p,
                editedUser: item?.id,
                desRoles: item?.roles,
              }));
            }}
          >
            Edit Roles
          </Button>
        </Popover>,
      ]}
    >
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
      <h1>User List</h1>
      <List
        loading={loading}
        itemLayout="horizontal"
        pagination={{ pageSize: 20 }}
        dataSource={state.users.sort((a, b) => b.id - a.id)}
        renderItem={renderItem}
      />
    </div>
  );
};

export default UserList;
