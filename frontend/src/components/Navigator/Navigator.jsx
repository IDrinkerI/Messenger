import React from "react";
import { useHistory } from "react-router";
import { HtmlContainer } from "../HtmlContainer";
import "./navigator.scss";


export const Navigator = () => {
    const history = useHistory();
    const onClickHandler = (event) => history.push(event.target.attributes["path"].value);

    return (
        <HtmlContainer>
            <nav>
                <ul className="navigator-link_wrapper">
                    <li path="/" onClick={onClickHandler}>Home</li>
                    <li path="/profile" onClick={onClickHandler}>Profile</li>
                    <li path="/signin" onClick={onClickHandler}>SignIn</li>
                    <li path="/signup" onClick={onClickHandler}>SignUp</li>
                </ul>
            </nav>
        </HtmlContainer>
    );
}
