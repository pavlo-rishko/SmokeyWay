import React, { FunctionComponent, useEffect } from "react";
import styled from "styled-components";

const StyledIframe = styled.iframe`display: none;`;

type BackgroundMusicPlayerProps = {
    songPath: string, 
    uniqueId: string
  }

export const BackgroundMusicPlayer: FunctionComponent<BackgroundMusicPlayerProps> = ({songPath, uniqueId}) =>
{
    let isPlay = false;

    useEffect(() => {
        PlayStop();
      }, [])

    const PlayStop = () =>
    {
        let value1: HTMLMediaElement = document.getElementById(uniqueId) as HTMLMediaElement;
        if (!isPlay) {
            value1?.play();
            isPlay = !isPlay;
        } else {
            value1?.pause();
            isPlay = !isPlay;
        }
    }

    return(
        <div>
            <StyledIframe allow="autoplay">
                <audio id={uniqueId} src={require("../public/offyou.mp3")} />
            </StyledIframe>
            <button onClick={PlayStop} type="button">Play</button>
        </div>
    )
}
export default BackgroundMusicPlayer;