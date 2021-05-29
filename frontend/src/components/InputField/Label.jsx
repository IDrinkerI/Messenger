import React from "react";

export const Label = (props) => {
    return (
        <label><span className="input_field-label">{props.label}</span>{props.children}</label>
    );
}