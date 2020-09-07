import React, {MouseEvent} from "react";
import { Link } from 'react-router-dom';
import styled from "styled-components";

const StyledLink = styled.div`
  padding: 20px;
  margin: 10px;
  border-radius: 40px;
  background-color: red;
  display: inline-block;
  box-shadow: 0px 0px 15px 2px #000000;
  &:hover {
    box-shadow: 5px 5px 15px 5px #FF8080,
    -9px 5px 15px 5px #FFE488, 
    -7px -5px 15px 5px #8CFF85, 
    12px -5px 15px 5px #80C7FF, 
    12px 10px 15px 7px #E488FF, 
    -10px 10px 15px 7px #FF616B, 
    -10px -7px 27px 1px #8E5CFF, 
    0px 0px 15px 2px rgba(0,0,0,0);
  }
  a {
    text-decoration: inherit;
    color: white;
  }
`;

const StyledNav = styled.div`
background-color: black;
`;

function bigImg(e: MouseEvent) {
    if(e.type === "mouseenter"){
        console.log(e.type)
    }
    if(e.type === "mouseleave"){
        console.log(e.type)
    }
  }
  
function Header(){
    return(
        <header>
            <StyledNav>
                <StyledLink>
                    <Link to="./">Smokey Way</Link>
                </StyledLink>
                <StyledLink onMouseEnter={bigImg} onMouseLeave={bigImg}>
                    <Link to="./">Головна</Link>
                </StyledLink>
                <StyledLink>
                    <Link to="./">Меню</Link>
                </StyledLink>
            </StyledNav>
        </header>
    )
}
export default Header;