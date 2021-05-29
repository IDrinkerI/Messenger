import React from "react";
import { useDispatch } from "react-redux";
import "./input_field.scss";


export const InputField = (props) => {
    const dispatch = useDispatch();
    const value = props.value;

    const onChangeHadler = (event) => {
        const text = event.target.value;
        dispatch(props.updateStorageAction(text))
    }

    return (
        <input type="text" className="input_field" value={value} onChange={onChangeHadler} />
    );
}
