import { BASE_URL, API_ENDPOINTS, useMockData } from "./constants/index";
import HttpRequest from "./utils/HttpRequest";
import Auth from "./utils/Auth";
import redirectTo from "./utils/redirectTo";
import AuthStore from "./utils/AuthStore";

const _sleep = (f = () => true, t = 350) => new Promise(r => setTimeout(r, t));

export async function getAllGroups(setState) {
  if (useMockData) return await _sleep();

  !Auth.isSignedIn() && redirectTo.login();

  const getGroupsUrl = BASE_URL + API_ENDPOINTS.groups;
  return await HttpRequest.get(getGroupsUrl).then(groups => {
    setState(p => ({ ...p, groups: [...groups] }));
  });
}

export async function getAllUsers(setState) {
  if (useMockData) return await _sleep();

  !Auth.isSignedIn() && redirectTo.login();

  const getUsersUrl = BASE_URL + API_ENDPOINTS.users;
  return await HttpRequest.get(getUsersUrl).then(users => {
    setState(p => ({ ...p, users: [...users] }));
  });
}

export async function changeRoles(body, execFunction) {
  if (useMockData) {
    execFunction();
    return await _sleep();
  }

  const changeRolesUrl = BASE_URL + API_ENDPOINTS.changeRoles;

  !Auth.isSignedIn() && redirectTo.login();
  return await HttpRequest.post(changeRolesUrl, body).then(execFunction);
}

export async function createGroup(body, state, execFunction) {
  if (useMockData) {
    execFunction(Math.max(state.groups.map(x => x.id)) + 1);
    return await _sleep();
  }

  const createGroupUrl = BASE_URL + API_ENDPOINTS.createGroup;

  !Auth.isSignedIn() && redirectTo.login();
  return await HttpRequest.post(createGroupUrl, body).then(execFunction);
}

export async function createCS(body, state, execFunction) {
  if (useMockData) {
    execFunction(Math.max(state.compSugg.map(x => x.id)) + 1);
    return await _sleep();
  }

  const createGroupUrl = BASE_URL + API_ENDPOINTS.createCS;

  !Auth.isSignedIn() && redirectTo.login();
  return await HttpRequest.post(createGroupUrl, body).then(execFunction);
}

export function getCurrentUserId() {
  if (useMockData) return 1;

  return AuthStore.userId;
}

export function getRandomNumber(min = 10, max = 500) {
  return Math.round(min - 0.5 + Math.random() * (max - min + 1));
}
