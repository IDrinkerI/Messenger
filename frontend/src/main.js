import "regenerator-runtime/runtime";
import React from "react";
import ReactDom from "react-dom";
import { Application } from "./components/Application";
import "./normalize.css";


ReactDom.render(<Application />, document.getElementById("app"));