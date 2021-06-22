import { API_ENDPOINTS, BASE_URL } from '../constants';
import AuthStore from './AuthStore';

const refreshTokenUrl = BASE_URL + API_ENDPOINTS.refresh;

export default class HttpRequest {
  static async send(url, options, needRefreshToken = true) {
    if (needRefreshToken) {
      await this.refreshToken();
    }

    options.headers.Authorization = `Bearer ${AuthStore?.getAuth()?.accessToken || null}`;

    // TODO: catch net::ERR_CONNECTION_REFUSED
    return fetch(url, options).then(response =>
      response.ok ? response.json() : Promise.reject(response.status)
    );
  }

  static async refreshToken() {
    const auth = AuthStore.getAuth();
    const now = new Date();
    const expairTime = new Date(auth.tokenExpiration);

    if (expairTime < now) {
      const body = {
        RefreshToken: auth.refreshToken,
        UserName: auth.username
      };

      return await this.post(refreshTokenUrl, body, true).then(
        AuthStore.setAuth
      );
    }
  }

  static async post(url, body, isRefreshTokenRequest) {
    const options = {
      method: 'POST',
      body: JSON.stringify(body),
      headers: {
        'Content-Type': 'application/json',
        Authorization: null
      }
    };
    return await this.send(url, options, !isRefreshTokenRequest);
  }

  static async get(url) {
    const options = {
      method: 'GET',
      headers: {
        'Content-Type': 'application/json',
        Authorization: null
      }
    };
    return await this.send(url, options);
  }

  static async delete(url, body) {
    return await this.pd(url, body, 'DELETE');
  }

  static async put(url, body) {
    return await this.pd(url, body, 'PUT');
  }

  /**
   * Don't use this method manually.
   */
  static async pd(url, body, method) {
    const options = {
      method: method,
      body: JSON.stringify(body),
      headers: {
        'Content-Type': 'application/json',
        Authorization: null
      }
    };
    return await this.send(url, options);
  }
}
