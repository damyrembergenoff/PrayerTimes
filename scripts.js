window.getUserLocation = function () {
    return new Promise(function (resolve, reject) {
        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(function (position) {
                resolve({
                    Latitude: position.coords.latitude,
                    Longitude: position.coords.longitude
                });
            }, function (error) {
                reject(error);
            });
        } else {
            reject("Geolocation not supported");
        }
    });
};