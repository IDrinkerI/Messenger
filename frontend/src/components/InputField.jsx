import React from "react";
import { useSelector } from "react-redux";
import { useDispatch } from "react-redux";
import { updateInputMessageAction } from "../store/input_message/actions";
import { inputMessageSelector } from "../store/input_message/selectors";
import "../style/input_field.scss";


const InputField = () => {
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

export default InputField;