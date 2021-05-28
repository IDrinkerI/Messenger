import React from "react";
import "./messenger_button.scss";

export const Button = (props) => (
    <button className="messenger_button" onClick={props.onClick}>{props.children}</button>
);
