import React from "react";
import { useSelector } from "react-redux";
import { useDispatch } from "react-redux";
import { updateInputMessageAction } from "./store/actions";
import { inputMessageSelector } from "./store/selectors";
import "./input_field.scss";


export const InputField = () => {
    const dispatch = useDispatch();
    const value = useSelector(inputMessageSelector);
    const onChangeHadler = (event) => {
        const text = event.target.value;
        dispatch(updateInputMessageAction(text))
    }

    return (
        <input type="text" className="input_field" value={value} onChange={onChangeHadler} />
    );
}
