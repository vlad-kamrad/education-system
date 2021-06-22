import React from 'react';
import { BrowserRouter as Router, Switch, Route } from 'react-router-dom';
import EDUContextProvider from './contexts/EDU.Context.Provider';
import LoginForm from './components/auth/login/LoginForm';
import RegisterForm from './components/auth/register/RegisterForm';
import UserList from './components/userList/UserList';
import DepartmentsList from './components/departmentsList/DepartmentsList';
import { initialNotesState } from './constants/index';
import './App.css';

function App() {
  return (
    <EDUContextProvider initialState={initialNotesState}>
      <Router>
        <Switch>
          <Route path='/login'>
            <LoginForm />
          </Route>
          <Route path='/registration'>
            <RegisterForm />;
          </Route>
          <Route path='/user-list'>
            <UserList />
          </Route>
          <Route path='/departments-list'>
            <DepartmentsList />
          </Route>
        </Switch>
      </Router>
    </EDUContextProvider>
  );
}

export default App;
