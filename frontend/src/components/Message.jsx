import React from "react";
import "../style/message.scss";

const Message = (props) => {
    const { userName, messageText } = props.message;

    return (
        <div className="message">
            <p className="message-user_name">{userName}:</p>
            <p className="message-text">{messageText}</p>
        </div>
    );
}

export default Message;