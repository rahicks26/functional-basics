/**
 * Creates a new array from the provided values
 * that is the result of invoking func on each value.
 * @param {Array} arr 
 * @param {Function} func 
 * 
 * @returns {Array}
 */
function map(arr, func){
    if(!arr || !Array.isArray(arr)) return arr;
    if(!func || typeof func !== 'function') return arr;

    const _map = (arr, func) => {
        for (const item of arr) {
            yield func(item); 
        }
    }

    return Array.from(_map(arr,func));
}

/**
 * Creates a new array that has been filtered by 
 * the provided fucntion.
 * @param {Array} arr 
 * @param {Function} func 
 * 
 * @returns {Array}
 */
function filter(arr, func){
    if(!arr || !Array.isArray(arr)) return arr;
    if(!func || typeof func !== 'function') return arr;

    const _filter = (arr, func) => {
        for (const item of arr) {
            if(func(item)) yield item; 
        }};

    return Array.from(_filter(arr,func));
}

/**
 * Applies the folder to every item and returns the result.
 * @param {Array} arr 
 * @param {Function} func 
 * @param {Any} acc 
 */
function fold(arr, func, acc){
    if(!arr || !Array.isArray(arr)) return arr;
    if(!func || typeof func !== 'function') return arr;

    let _acc = acc;
    for (const item of arr) {
        _acc = func(item, _acc);
    }

    return _acc;
}