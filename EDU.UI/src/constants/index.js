import mock from "../utils/mock";
import _package from "../../package.json";

export { default as API_ENDPOINTS } from "./apiEndpoints";
export { default as MESSAGES } from "./messages";

export const BASE_URL = "https://localhost:5001/api";

export const useMockData = _package.config.useMockData;
export const initialState = useMockData
  ? mock
  : {
      users: [],
    };
