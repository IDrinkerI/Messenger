import React from "react";
import "./input_field.scss";
import { Label } from "./Label.jsx";


const InputField = (props) => {
    return (
        <input type="text" className="input_field" value={props.value} onChange={props.onChange}
            style={{ ...props.style }} />
    );
}

InputField.Label = Label;

export default InputField;
