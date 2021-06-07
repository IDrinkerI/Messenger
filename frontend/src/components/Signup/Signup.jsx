import React, { useState } from "react";
import { Button } from "../Button";
import { HtmlContainer } from "../HtmlContainer";
import { InputField } from "../InputField";
import "./signup.scss";


const API = "/api/signup";

export const Signup = () => {
    const [email, setEmeil] = useState("");
    const [password, setPassword] = useState("");
    const [confirmPassword, setConfirmPassword] = useState("");

    // TODO: DRY
    const emailOnChangeHandler = ({ target }) => {
        const value = target.value;
        setEmeil(value);
    }

    // TODO: DRY
    const passwordOnChangeHandler = ({ target }) => {
        const value = target.value;
        setPassword(value);
    }

    // TODO: DRY
    const confirmPasswordOnChangeHandler = ({ target }) => {
        const value = target.value;
        setConfirmPassword(value);
    }

    const onClickButtonHandler = async (event) => {
        event.preventDefault();

        if (password !== confirmPassword) { return; }

        if (process.env.NODE_ENV == "development") {
            console.log({ newUser: { email, password } });
        }

        await fetch(API, {
            method: "PUT",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify({ email, password }),
        });

        setEmeil("");
        setPassword("");
        setConfirmPassword("");
    }

    return (
        <HtmlContainer>
            <form className="signup-inner">
                <h3>SignUp</h3>
                <InputField.Label label="Email:">
                    <InputField value={email} onChange={emailOnChangeHandler} />
                </InputField.Label>

                <InputField.Label label="Password:">
                    <InputField value={password} onChange={passwordOnChangeHandler} />
                </InputField.Label>

                <InputField.Label label="Confirm pwd:">
                    <InputField value={confirmPassword} onChange={confirmPasswordOnChangeHandler} />
                </InputField.Label>

                <Button onClick={onClickButtonHandler}>
                    Signup
                 </Button>
            </form>
        </HtmlContainer>
    );
}
