import React from 'react';
import { Map as LeafletMap, TileLayer, Marker, Popup } from 'react-leaflet';
import "leaflet/dist/leaflet.css";

interface PositionMapProps { 
    position?: L.LatLngLiteral; 
    popUpText?: string; 
    height?: string; 
    width?: string;
    zoom?: number;
    borderRadius?: string;
}

function PositionMap(props: PositionMapProps)
{
    const {position = [49.84454, 24.026750] as unknown as L.LatLngLiteral,
        popUpText = "",
        height = "500px",
        width = "700px",
        zoom = 10,
        borderRadius = "30px"
    } = props;

    const L = require("leaflet");
    
    React.useEffect(() => {    
        delete L.Icon.Default.prototype._getIconUrl;
            
        L.Icon.Default.mergeOptions({
          iconRetinaUrl: require("leaflet/dist/images/marker-icon-2x.png"),
          iconUrl: require("leaflet/dist/images/marker-icon.png"),
          shadowUrl: require("leaflet/dist/images/marker-shadow.png")
        });
      }, []);

    return(
        <LeafletMap center={position} zoom={zoom} style={{height: height, width: width, borderRadius: borderRadius}}>
            <TileLayer maxZoom={22}
            attribution='<a href="https://www.maptiler.com/copyright/" target="_blank">&copy; MapTiler</a> <a href="https://www.openstreetmap.org/copyright" target="_blank">&copy; OpenStreetMap contributors</a>'
            url='https://api.maptiler.com/maps/basic/{z}/{x}/{y}.png?key=L7jWH8UlPu3enKseP3Nw'
            />
            <Marker position={position}>
                <Popup>
                    {popUpText}
                </Popup>
            </Marker>
        </LeafletMap>
    );
}
export default PositionMap;
