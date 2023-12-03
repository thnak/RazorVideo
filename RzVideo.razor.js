export class DOMCleanup {
    static observer;

    static createObserver(uuid) {
        const target = document.getElementById(uuid);

        this.observer = new MutationObserver(function (mutations) {
            const targetRemoved = mutations.some(function (mutation) {
                const nodes = Array.from(mutation.removedNodes);
                return nodes.indexOf(target) !== -1;
            });

            if (targetRemoved) {
                // Cleanup resources here
                // ...

                // Disconnect and delete MutationObserver
                this.observer && this.observer.disconnect();
                delete this.observer;
            }
        });

        this.observer.observe(target.parentNode, {childList: true});
    }
}

export function log(message) {
    console.log(message);
}

export async function VideoStreaming(elementID, imgStream) {
    const array = await imgStream.arrayBuffer();
    const blob = new Blob([array]);
    const url = URL.createObjectURL(blob);
    const video = document.getElementById(elementID);
    const childNodes = video.childNodes;
    for (var i = 0; i < childNodes.length; i++) {
        childNodes[i].src = url;
    }
    video.onload = () => {
        URL.revokeObjectURL(url)
    }
    video.src = url;
    video.addEventListener("contextmenu", e => e.preventDefault());
}

export function videoEvents(elementID, command) {
    const element = document.getElementById(elementID);
    if (element) {
        switch (command) {
            case "play": {
                if (element.paused) {
                    element.play();
                }
                break;
            }
            case "pause": {
                if (!element.paused) {
                    element.pause();
                }
                break;
            }
            case "re-load": {
                element.load();
                break;
            }
            case "reset": {
                const source = video.childNodes;
                for (var i = 0; i < source.length; i++) {
                    source[i].src = "";
                }
                element.src = "";
            }
            default: {
            }
        }
    }

}

export function videoSetSpeed(elementID, speed) {
    const element = document.getElementById(elementID);
    if (element) {
        element.playbackRate = speed;
    }
}

export async function videoInfo(elementID) {
    const video = document.getElementById(elementID);

    var json = {};
    if (video) {
        var listSrc = [];
        const source = video.childNodes;
        source.forEach((e) => {
            if (e.nodeName === "SOURCE") {
                listSrc.push(e.src)
            }
        })
        
        json["Duration"] = video.duration;
        json["BufferedEnd"] = video.buffered.end(0);
        json["BufferedStart"] = video.buffered.start(0);
        json["BufferedLength"] = video.buffered.length;
        json["CurrentTime"] = video.currentTime;
        json["Sources"] = listSrc;
        json["Poster"] = video.poster;
        json["Muted"] = video.muted;
        json["Volume"] = video.volume;
        json["Loop"] = video.loop;
        json["DefaultPlaybackRate"] = video.defaultPlaybackRate;
        json["Paused"] = video.paused;
        json["PlaybackRate"] = video.playbackRate;
        json["Dimension"] = {"Height": video.videoHeight, "Width": video.videoWidth};
        console.log(json)
        // console.log(JSON.stringify(json));
        return JSON.stringify(json);

    } else {
        return "";
    }
}

window.DOMCleanup = DOMCleanup;