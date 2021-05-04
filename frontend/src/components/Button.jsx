import React from "react";
import "../style/messenger_button.scss";

const Button = (props) => (
    <button className="messenger_button" onClick={props.onClick}>{props.children}</button>
);

export default Button;