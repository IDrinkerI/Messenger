import React from "react";
import { useHistory } from "react-router";
import { HtmlContainer } from "../HtmlContainer";
import "./navigator.scss";


export const Navigator = () => {
    const history = useHistory();
    const homeLinkClickHandler = () => { history.push("/"); }
    const profileLinkClickHandler = () => history.push("/profile");

    return (
        <HtmlContainer>
            <nav>
                <ul className="navigator-link_wrapper">
                    <li onClick={homeLinkClickHandler}>Home</li>
                    <li onClick={profileLinkClickHandler}>Profile</li>
                </ul>
            </nav>
        </HtmlContainer>
    );
}
