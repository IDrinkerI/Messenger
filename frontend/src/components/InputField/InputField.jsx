import React from "react";
import { useSelector } from "react-redux";
import { useDispatch } from "react-redux";
import "./input_field.scss";


export const InputField = (props) => {
    const dispatch = useDispatch();
    const value = useSelector(props.valueSelector);

    const onChangeHadler = (event) => {
        const text = event.target.value;
        dispatch(props.updateValueAction(text))
    }

    return (
        <input type="text" className="input_field" value={value} onChange={onChangeHadler} />
    );
}
