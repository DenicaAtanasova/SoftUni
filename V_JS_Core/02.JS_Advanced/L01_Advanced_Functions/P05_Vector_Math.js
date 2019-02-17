let vectorCalculator = (function (){

    const add = ([xA, yA], [xB, yB]) => {
        return [xA + xB, yA + yB];
    }

    const multiply = ([xA, yA], s) => {
        return [xA * s, yA * s];
    }

    const length = ([xA, yA]) => {
        return Math.sqrt(xA ** 2 + yA ** 2);
    }

    const dot = ([xA, yA], [xB, yB]) => {
        return xA * xB + yA * yB;
    }

    const cross = ([xA, yA], [xB, yB]) => {
        return xA * yB - xB * yA;
    }

    return {
        add,
        multiply,
        length,
        dot,
        cross
    }
})();

console.log(vectorCalculator.cross([3, 7], [1, 0]));