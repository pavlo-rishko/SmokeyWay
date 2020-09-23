import React from "react";
import styled from "styled-components";

const StyledDivBLock = styled.div`
width: 100vw;
height: ${window.innerHeight}px;
visibility: visible;
`;

function BodyHomePage()
{
    return(
        <div style={{position: "absolute", top: "1px", zIndex: -1}}>
            <StyledDivBLock style={{backgroundColor: "red"}}>lol</StyledDivBLock>
            <StyledDivBLock style={{backgroundColor: "black"}}>lol2</StyledDivBLock>
            <StyledDivBLock style={{backgroundColor: "pink"}}>lol</StyledDivBLock>
        </div>
    )
}
export default BodyHomePage;