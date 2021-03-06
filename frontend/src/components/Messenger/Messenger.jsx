import React, { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import { MessageModel } from "../../models/MessageModel";
import { Button } from "../Button";
import { ChatList, currentChatIdSelector } from "../ChatList";
import { HtmlContainer } from "../HtmlContainer";
import { InputField } from "../InputField";
import { inputMessageSelector, updateInputMessageAction } from "../InputMessage";
import { MessageField, addMessageAction } from "../MessageField";
import { initProfileAction } from "../Profile/store/actions";
import "./messenger.scss";


export const Messenger = () => {
    const dispatch     = useDispatch();
    const inputMessage = useSelector(inputMessageSelector);
    const chatId       = useSelector(currentChatIdSelector);

    const buttonHandler = (event) => {
        event.preventDefault();
        if (!inputMessage) { return; }

        const message = new MessageModel();
        message.text   = inputMessage;
        message.chatId = chatId;

        dispatch(addMessageAction(message));
        dispatch(updateInputMessageAction(""));
    }

    const inputFieldOnChangeHandler = (event) => {
        const text = event.target.value;
        dispatch(updateInputMessageAction(text));
    }

    useEffect(() => {
        dispatch(initProfileAction())
    }, []);

    return (
        <HtmlContainer>
            <div className="messenger">
                <div className="messenger_inner">
                    <ChatList />
                    <MessageField />
                </div>

                <form className="messenger_inner">
                    <InputField
                        style={{ "flex-grow": "1" }}
                        value={inputMessage}
                        onChange={inputFieldOnChangeHandler}
                    />

                    <Button onClick={buttonHandler}>Send</Button>
                </form>
            </div>
        </HtmlContainer>
    );
}
