import React from "react";
import "./input_field.scss";


export const InputField = (props) => {
    return (
        <input type="text" className="input_field" value={props.value} onChange={props.onChange} />
    );
}
