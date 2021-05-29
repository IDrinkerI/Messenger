import React from "react";
import { useDispatch, useSelector } from "react-redux";
import { MessageModel } from "../../models/MessageModel";
import { Button } from "../Button";
import { ChatList } from "../ChatList";
import { HtmlContainer } from "../HtmlContainer";
import { InputField } from "../InputField";
import { inputMessageSelector, updateInputMessageAction } from "../InputMessage";
import { MessageField, addMessageAction } from "../MessageField";
import "./messenger.scss";


export const Messenger = () => {
    const dispatch = useDispatch();
    const inputMessage = useSelector(inputMessageSelector);

    const buttonHandler = () => {
        const message = new MessageModel("bot", inputMessage);
        dispatch(addMessageAction(message));
        dispatch(updateInputMessageAction(""));
    }

    return (
        <HtmlContainer>
            <div className="messenger">
                <div className="messenger_inner">
                    <ChatList />
                    <MessageField />
                </div>

                <div className="messenger_inner">
                    <InputField value={inputMessage} updateStorageAction={updateInputMessageAction} />
                    <Button onClick={buttonHandler}>Send</Button>
                </div>
            </div>
        </HtmlContainer>
    );
}
