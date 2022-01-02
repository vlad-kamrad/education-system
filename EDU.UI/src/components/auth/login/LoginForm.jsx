import React, { useState, useEffect } from 'react';
import { Form, Button, Spinner, Alert } from 'react-bootstrap';
import Auth from '../../../utils/Auth';
import MESSAGES from '../../../constants/messages';
import redirectTo from '../../../utils/redirectTo';

import './LoginForm.css';

const LoginForm = () => {
  const [{ username, password, pending }, setState] = useState({
    pending: false
  });

  const [errorMessage, setErrorMessage] = useState(null);

  const onChangeHandler = e => handler => handler(e.target.value);
  const onChangeUsername = username => setState(p => ({ ...p, username }));
  const onChangePassword = password => setState(p => ({ ...p, password }));

  useEffect(() => {
    if (pending) {
      (async () => {
        const body = {
          username,
          password: password
        };

        await Auth.signIn(body)
          .then(() => {
            setState(p => ({ ...p, pending: false }));
            redirectTo.index();
          })
          .catch(status => {
            setState(p => ({ ...p, pending: false }));
            handleError(status);
          });
      })();
    }
  }, [pending, username, password]);

  const handleError = status => {
    switch (status) {
      case 400:
        setErrorMessage(MESSAGES.LOGIN_VALID_PARAMS);
        break;
      case 403:
        setErrorMessage(MESSAGES.LOCKED_USER);
        break;
      case 404:
        setErrorMessage(MESSAGES.WRONG_USER_CREDS);
        break;
      default:
        setErrorMessage(MESSAGES.WRONG_USER_CREDS);
    }
  };

  const onClickHandler = () => {
    if (!username || !password) {
      setErrorMessage(MESSAGES.EMPTY_FIRLDS);
      return;
    }
    setState(p => ({ ...p, pending: true }));
    setErrorMessage(null);
  };

  return (
    <>
      {errorMessage && (
        <Alert
          key='error'
          variant='danger'
          onDoubleClick={() => console.log('double')}
        >
          {errorMessage}
        </Alert>
      )}
      <div className='container'>
        <Form.Group>
          <Form.Label>Username</Form.Label>
          <Form.Control
            type='text'
            placeholder='Enter username'
            onChange={e => onChangeHandler(e)(onChangeUsername)}
          />
        </Form.Group>

        <Form.Group>
          <Form.Label>Password</Form.Label>
          <Form.Control
            type='password'
            placeholder='Password'
            onChange={e => onChangeHandler(e)(onChangePassword)}
          />
        </Form.Group>
        <Button
          variant='primary'
          onClick={onClickHandler}
          className='submitBtn'
        >
          {pending ? (
            <Spinner
              as='span'
              animation='border'
              size='sm'
              role='status'
              aria-hidden='true'
            />
          ) : (
            'Login'
          )}
        </Button>
        <Button variant='light' onClick={redirectTo.registration}>
          Registration
        </Button>
        <Button
          variant='light'
          onClick={() => console.log('forget password page')}
        >
          Forget Password
        </Button>
      </div>
    </>
  );
};

export default LoginForm;
