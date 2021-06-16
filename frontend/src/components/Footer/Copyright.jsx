import React from "react";
import { HtmlContainer } from "../HtmlContainer";
import "./footer.scss";


export const Copyright = () => {
    return (
        <div className="footer-copyright">
            <HtmlContainer>
                <span className="footer-copyright_text">&copy; 2022 Messenger</span>
            </HtmlContainer>
        </div>
    );
}

