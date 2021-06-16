import React, { useState } from "react";
import { RestClient } from "../../utils";
import { Button } from "../Button";
import { HtmlContainer } from "../HtmlContainer";
import { InputField } from "../InputField";
import "./signin.scss";

const API_URL = "signin/";

export const Signin = () => {
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");

    // TODO: DRY
    const emailOnChangeHandler = ({ target }) => {
        const value = target.value;
        setEmail(value);
    }

    // TODO: DRY
    const passwordOnChangeHandler = ({ target }) => {
        const value = target.value;
        setPassword(value);
    }

    const signinButtonHandler = async (event) => {
        event.preventDefault();

        /*const response =*/
        await RestClient.postAsync(API_URL, { email, password });
        //const signinResult = await response.status;

        setEmail("");
        setPassword("");
    }

    return (
        <HtmlContainer>
            <form className="signin-inner">
                <h3>SingIn</h3>
                <InputField.Label label="Email:">
                    <InputField value={email} onChange={emailOnChangeHandler} />
                </InputField.Label>

                <InputField.Label label="Password:">
                    <InputField value={password} onChange={passwordOnChangeHandler} />
                </InputField.Label>

                <Button onClick={signinButtonHandler}>
                    Signin
                </Button>
            </form>
        </HtmlContainer>
    )
}
