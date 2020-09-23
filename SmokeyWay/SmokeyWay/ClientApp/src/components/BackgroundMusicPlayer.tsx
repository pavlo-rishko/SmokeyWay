import React, { FunctionComponent } from "react";
import styled from "styled-components";

const StyledIframe = styled.iframe`display: none;`;

type BackgroundMusicPlayerProps = {
    songPath: string, 
    uniqueId: string
  }

export const BackgroundMusicPlayer: FunctionComponent<BackgroundMusicPlayerProps> = ({songPath, uniqueId}) =>
{
    return(
        <div>
            <StyledIframe allow="autoplay">
                <audio id={uniqueId} autoPlay src={songPath} />
            </StyledIframe>
        </div>
    )
}
export default BackgroundMusicPlayer;