export default class AuthStore {
  static setAuth({
    AccessToken,
    RefreshToken,
    TokenExpiration,
    UserName,
    Roles
  }) {
    // TODO: Change to contextApi
    window.localStorage.setItem('accessToken', AccessToken);
    window.localStorage.setItem('refreshToken', RefreshToken);
    window.localStorage.setItem('tokenExpiration', TokenExpiration);
    window.localStorage.setItem('username', UserName);
    window.localStorage.setItem('roles', JSON.stringify(Roles));
    // Roles
  }

  static getAuth() {
    return {
      accessToken: window.localStorage.getItem('accessToken'),
      refreshToken: window.localStorage.getItem('refreshToken'),
      tokenExpiration: window.localStorage.getItem('tokenExpiration'),
      username: window.localStorage.getItem('username'),
      roles: JSON.parse(window.localStorage.getItem('roles'))
    };
  }

  static removeAuth() {
    window.localStorage.removeItem('accessToken');
    window.localStorage.removeItem('refreshToken');
    window.localStorage.removeItem('tokenExpiration');
    window.localStorage.removeItem('username');
    window.localStorage.removeItem('roles');
  }
}
