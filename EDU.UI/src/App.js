import React from "react";
import { BrowserRouter as Router, Switch, Route } from "react-router-dom";
import LoginForm from "./components/auth/login/LoginForm";
import RegisterForm from "./components/auth/register/RegisterForm";
import UserList from "./components/userList/UserList";
import DepartmentsList from "./components/departmentsList/DepartmentsList";
import { initialState } from "./constants/index";
import EDUContext from "./contexts/EDU.Context";
import AppLayout from "./components/Layout";

import "./App.css";
import Groups from "./components/Groups";
import TeacherList from "./components/TeacherList";
import Courses from "./components/Courses";
import ComplaintsSuggestions from "./components/ComplaintsSuggestions";

function App() {
  const [_, setContext] = React.useContext(EDUContext);
  React.useEffect(() => setContext(initialState), []);

  return (
    <Router>
      <Switch>
        <Route path="/login">
          <AppLayout>
            <LoginForm />
          </AppLayout>
        </Route>
        <Route path="/registration">
          <AppLayout>
            <RegisterForm />
          </AppLayout>
        </Route>
        <Route path="/user-list">
          <AppLayout>
            <UserList />
          </AppLayout>
        </Route>
        <Route path="/departments-list">
          <AppLayout>
            <DepartmentsList />
          </AppLayout>
        </Route>
        <Route path="/group-list">
          <AppLayout>
            <Groups />
          </AppLayout>
        </Route>
        <Route path="/teacher-list">
          <AppLayout>
            <TeacherList />
          </AppLayout>
        </Route>
        <Route path="/courses-list">
          <AppLayout>
            <Courses />
          </AppLayout>
        </Route>
        <Route path="/complaints-suggestions">
          <AppLayout>
            <ComplaintsSuggestions />
          </AppLayout>
        </Route>
        <Route path="/">
          <AppLayout>
            <Courses />
          </AppLayout>
        </Route>
      </Switch>
    </Router>
  );
}

export default App;
