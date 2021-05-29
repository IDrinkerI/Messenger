import React, { useEffect, useState } from "react";
import { useDispatch } from "react-redux";
import { Button } from "../Button";
import { HtmlContainer } from "../HtmlContainer";
import { InputField } from "../InputField";
import "./profile.scss";
import { changeProfileAction, initProfileAction } from "./store/actions";

export const Profile = () => {
    const dispatch = useDispatch();
    const [profile, setProfile] = useState({});

    const inputFieldOnChangeHandler = (event) => {
        const nickname = event.target.value;
        setProfile({ ...profile, nickname });
    }

    const saveButtonHandler = () => {
        dispatch(changeProfileAction(profile));
    }

    useEffect(() => {
        dispatch(initProfileAction())
    }, []);

    return (
        <HtmlContainer>
            <h3>Profile</h3>
            <InputField.Label label="New nickname:">
                <InputField onChange={inputFieldOnChangeHandler} />
            </InputField.Label>

            <br />
            <Button onClick={saveButtonHandler}>Save</Button>
        </HtmlContainer>
    );
}
