import React, { useEffect, useState } from "react";
import { useDispatch } from "react-redux";
import { Button } from "../Button";
import { HtmlContainer } from "../HtmlContainer";
import { InputField } from "../InputField";
import { changeProfileAction, initProfileAction } from "./store/actions";
import "./profile.scss";


export const Profile = () => {
    const dispatch = useDispatch();
    const [nickname,  setNickname]  = useState("");
    const [firstname, setFirstname] = useState("");
    const [lastname,  setLastname]  = useState("");

    const nicknameOnChangeHandler = (event) => {
        const newValue = event.target.value;
        setNickname(newValue);
    }

    const firstnameOnChangeHandler = (event) => {
        const newValue = event.target.value;
        setFirstname(newValue);
    }

    const lastnameOnChangeHandler = (event) => {
        const newValue = event.target.value;
        setLastname(newValue);
    }

    const saveButtonHandler = () => {
        event.preventDefault();

        const profileState = {
            nickname,
            firstname,
            lastname,
        };

        dispatch(changeProfileAction(profileState));

        setNickname("");
        setFirstname("");
        setLastname("");
    }

    useEffect(() => {
        dispatch(initProfileAction())
    }, []);


    return (
        <HtmlContainer>
            <form className="profile-inner">
                <h3>Profile setup</h3>
                <InputField.Label label="Nickname:">
                    <InputField value={nickname} onChange={nicknameOnChangeHandler} />
                </InputField.Label>
                <InputField.Label label="Firstname:">
                    <InputField value={firstname} onChange={firstnameOnChangeHandler} />
                </InputField.Label>
                <InputField.Label label="Lastname:">
                    <InputField value={lastname} onChange={lastnameOnChangeHandler} />
                </InputField.Label>

                <br />
                <Button onClick={saveButtonHandler}>Save</Button>
            </form>
        </HtmlContainer>
    );
}
