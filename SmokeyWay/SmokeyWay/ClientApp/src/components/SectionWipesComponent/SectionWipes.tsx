import React from 'react';
import styled from 'styled-components';
import { Controller, Scene } from 'react-scrollmagic';
import { Tween, Timeline } from 'react-gsap';

const SectionWipesStyled = styled.div`
  overflow: hidden;

  #pinContainer {
    height: 100vh;
    width: 100vw;
    overflow: hidden;
  }

  #pinContainer .panel {
    height: 100vh;
    width: 100vw;
    position: absolute;
    text-align: center;
  }

  .panel span {
    position: relative;
    display: block;
    top: 50%;
    font-size: 80px;
  }
  
  .panel.blue {
    background-color: #3883d8;
  }
  
  .panel.turqoise {
    background-color: #38ced7;
  }
  
  .panel.green {
    background-color: #22d659;
  }
  
  .panel.bordeaux {
    background-color: #953543;
  }

`;

const SectionWipes = () => (
  <SectionWipesStyled>
    <Controller>
      <Scene
        triggerHook="onLeave"
        duration="300%"
        pin
      >
        <Timeline wrapper={<div id="pinContainer" />}>
          <section className="panel blue">
              <span>
                  LOL1
              </span>
          </section>
          <Tween from={{ x: '-100%' }} to={{ x: '0%' }}>
            <section className="panel turqoise">
                <span>
                    LOL2
                </span>
            </section>
          </Tween>
          <Tween from={{ x: '100%' }} to={{ x: '0%' }}>
            <section className="panel green">
                <span>
                    LOL3
                </span>
            </section>
          </Tween>
          <Tween from={{ y: '-100%' }} to={{ y: '0%' }}>
            <section className="panel bordeaux">
                <span>
                    LOL4
                </span>
            </section>
          </Tween>
        </Timeline>
      </Scene>
    </Controller>
  </SectionWipesStyled>
);

export default SectionWipes;
