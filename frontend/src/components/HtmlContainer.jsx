import React from "react";
import "../style/container.scss"


const HtmlContainer = (props) => (
    <div className="container">{props.children}</div>
);

export default HtmlContainer;