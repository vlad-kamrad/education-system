import AuthStore from './AuthStore';
import { BASE_URL, API_ENDPOINTS } from '../constants';
import HttpRequest from './HttpRequest';
import redirectTo from '../utils/redirectTo';

const loginUrl = BASE_URL + API_ENDPOINTS.login;
const registerUrl = BASE_URL + API_ENDPOINTS.register;

export default class Auth {
  static isSignedIn() {
    return !!AuthStore.getAuth().accessToken;
  }

  static async signIn(body) {
    return await HttpRequest.post(loginUrl, body, true).then(AuthStore.setAuth);
  }

  static async register(body) {
    return await HttpRequest.post(registerUrl, body, true).then(res => {
      debugger;
    });
  }

  static signOut() {
    AuthStore.removeAuth();
    redirectTo.login();
  }

  static handleRejections(error) {
    // Error 401 : Unauthorized
    if (error.response.status === 401) {
      this.logUserOut();
    }
  }

  static logUserOut() {
    AuthStore.removeToken();
    window.location = '/login';
  }
}
