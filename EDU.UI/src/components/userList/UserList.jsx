import React, { useState, useEffect, useContext } from 'react';
import { List, Skeleton, Button, Popover, Checkbox, notification } from 'antd';
import Auth from '../../utils/Auth';
import redirectTo from '../../utils/redirectTo';
import { MESSAGES } from '../../constants/index';
import { BASE_URL, API_ENDPOINTS } from '../../constants/index';
import HttpRequest from '../../utils/HttpRequest';
import EDUContext from '../../contexts/EDU.Context';

import './UserList.css';

const getUsersUrl = BASE_URL + API_ENDPOINTS.users;
const changeRolesUrl = BASE_URL + API_ENDPOINTS.changeRoles;

const UserList = () => {
  const [loading, setLoading] = useState(false);
  const [state, setState] = useContext(EDUContext);
  const [{ editedUser, desRoles }, setEditedUser] = useState({ desRoles: [] });

  useEffect(() => {
    !Auth.isSignedIn() && redirectTo.login();
  }, []);

  useEffect(() => {
    setLoading(true);
    (async () => {
      await HttpRequest.get(getUsersUrl).then((users) => {
        setState(p => ({ ...p, users: [...users] }));
        setLoading(false);
      });
    })();
  }, []);

  const showSuccesEdited = () => {
    notification['success']({
      message: MESSAGES.SUCCESS,
      description: MESSAGES.SUCCESS_CREATED_TEXT,
      placement: 'bottomLeft'
    });
  };

  const renderUserRolesBlock = userId => {
    const { roles } = state.users.filter(x => x.id === userId)[0];
    const allRoles = state.roles;
    return (
      <div className='chbxs'>
     {/*    {allRoles.map((role, i) => {
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
                      desRoles: roles
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
        })} */}
        <Button
          onClick={async () => {
            await HttpRequest.post(changeRolesUrl, {
              userId,
              DesiredRoles: desRoles
            }).then(res => {
              const usrs = state.users.map(x => {
                if (x.id === userId) {
                  x.roles = res.map(d => d.name);
                  return x;
                }
                return x;
              });
              setState(p => ({ ...p, users: usrs }));
              showSuccesEdited();
            });
          }}
        >
          Save Changes
        </Button>
      </div>
    );
  };

  const renderItem = item => (
    <List.Item
      key={item.id}
      onClick={() => {}}
      actions={[
        <Popover
          placement='left'
          title={'Title'}
          content={renderUserRolesBlock(item.id)}
          trigger='click'
          destroyTooltipOnHide={true}
        >
          <Button
            onClick={() => {
              setEditedUser(p => ({
                ...p,
                editedUser: item?.id,
                desRoles: item?.roles
              }));
            }}
          >
            Edit Roles
          </Button>
        </Popover>
      ]}
    >
      <Skeleton loading={loading} title={false} active>
        <div>
          <List.Item.Meta title={item?.email} />
          {`${item?.name} ${item?.surname}`}
        </div>
      </Skeleton>
    </List.Item>
  );

  const renderBody = () => {
    return;
  };

  return (
    <div className='body'>
      <List
        loading={loading}
        itemLayout='horizontal'
        pagination={{
          onChange: page => console.log(page),
          pageSize: 5
        }}
        dataSource={state.users.sort((a, b) => b.id - a.id)}
        renderItem={renderItem}
      />
    </div>
  );
};

export default UserList;
