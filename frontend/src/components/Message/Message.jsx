import React from "react";
import "./message.scss";


export const Message = (props) => {
    const { userName, messageText } = props.message;

    return (
        <div className="message">
            <p className="message-user_name">{userName}:</p>
            <p className="message-text">{messageText}</p>
        </div>
    );
}
