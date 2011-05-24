var CallCacher = function () { };

CallCacher.prototype.applyCacheToCall = function (functionName, target) {

    var cachedFunctionName = '__' + functionName;
    target[cachedFunctionName] = target[functionName];

    var wrappedCall = function () {

        var parametersOfCachedFunction = [];
        var resultOfCachedFunction = {};

        var cacheAndCallCheck = function () {

            var refreshCache = false;

            if (parametersOfCachedFunction.length !== arguments.length) {
                refreshCache = true;
            } else {
                for (var index = 0, length = parametersOfCachedFunction.length; index < length; index++) {
                    if (parametersOfCachedFunction[index] !== arguments[index]) {
                        refreshCache = true;
                        break;
                    }
                }
            }

            if (refreshCache) {
                resultOfCachedFunction = target[cachedFunctionName].apply(target, arguments);
                parametersOfCachedFunction = arguments;
            }

            return resultOfCachedFunction;

        };

        return cacheAndCallCheck;

    } ();

    target[functionName] = wrappedCall;

};

CallCacher.prototype._hasParametersChanged = function (cachedArgs, newArgs) { 

};