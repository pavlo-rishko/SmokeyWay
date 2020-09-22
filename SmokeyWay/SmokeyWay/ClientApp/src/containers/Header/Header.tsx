import React from "react";
import { Link } from 'react-router-dom';
import styled from "styled-components";
import Logo from '../../public/SmokeyWayLogo.svg';
const StyledLogo = styled.img`
  height: 80px;
  padding-left: 0;
  float: left;
`;

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
  width: 100%;
  background-color: silver;
`;
  
function Header(){

    return(
        <header>
            <StyledNav>
                <StyledLogo src={Logo}></StyledLogo>
                <StyledLink>
                    <Link to="./">Smokey Way</Link>
                </StyledLink>
                <StyledLink>
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