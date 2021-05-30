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
                    <li path="/singin" onClick={onClickHandler}>SingIn</li>
                </ul>
            </nav>
        </HtmlContainer>
    );
}
