import React from "react";
import "./message.scss";


export const Message = (props) => {
    const { nickname, text } = props.message;

    return (
        <div className="message">
            <p className="message-user_name">{nickname}:</p>
            <p className="message-text">{text}</p>
        </div>
    );
}
