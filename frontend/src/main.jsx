import "regenerator-runtime/runtime";
import React from "react";
import ReactDom from "react-dom";
import Application from "./components/Application.jsx";
import "./style/normalize.css";


ReactDom.render(<Application />, document.getElementById("app"));