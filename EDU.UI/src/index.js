import React from "react";
import ReactDOM from "react-dom";
import "./index.css";
import App from "./App";
import { initialState } from "./constants/index";
import EDUContextProvider from "./contexts/EDU.Context.Provider";

ReactDOM.render(
  <React.StrictMode>
    <EDUContextProvider initialState={initialState}>
      <App />
    </EDUContextProvider>
  </React.StrictMode>,
  document.getElementById("root")
);
