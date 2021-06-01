import React, { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import { MessageModel } from "../../models/MessageModel";
import { Button } from "../Button";
import { ChatList } from "../ChatList";
import { HtmlContainer } from "../HtmlContainer";
import { InputField } from "../InputField";
import { inputMessageSelector, updateInputMessageAction } from "../InputMessage";
import { MessageField, addMessageAction } from "../MessageField";
import { profileNicknameSelector } from "../Profile";
import { initProfileAction } from "../Profile/store/actions";
import "./messenger.scss";


export const Messenger = () => {
    const dispatch = useDispatch();
    const inputMessage = useSelector(inputMessageSelector);
    const nickName = useSelector(profileNicknameSelector);

    const buttonHandler = () => {
        const message = new MessageModel(nickName, inputMessage);
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

                <div className="messenger_inner">
                    <InputField style={{ "flex-grow": "1" }} value={inputMessage} onChange={inputFieldOnChangeHandler} />
                    <Button onClick={buttonHandler}>Send</Button>
                </div>
            </div>
        </HtmlContainer>
    );
}
