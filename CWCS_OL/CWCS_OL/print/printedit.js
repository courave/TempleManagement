if (!document.getElementsByClassName) {
    document.getElementsByClassName = function(searchClass, node, tag) {
        var classElements = new Array();
        if (node == null)
            node = document;
        if (tag == null)
            tag = '*';
        var els = node.getElementsByTagName(tag);
        var elsLen = els.length;
        var pattern = new RegExp("(^|\\s)" + searchClass + "(\\s|$)");
        for (i = 0, j = 0; i < elsLen; i++) {
            if (pattern.test(els[i].className)) {
                classElements[j] = els[i];
                j++;
            }
        }
        return classElements;
    }
}

var saveedit = function() {
    var sform = document.getElementById("form1");
    var allFields = document.getElementsByClassName("field");
    for (repobj in allFields) {
        var afield = allFields[repobj];
        if ("object" != typeof afield) continue;
        
        sform.elements[afield.id + "_top"].value = afield.offsetTop;
        sform.elements[afield.id + "_left"].value = afield.offsetLeft;
        sform.elements[afield.id + "_width"].value = afield.clientWidth;
        sform.elements[afield.id + "_height"].value = afield.clientHeight;
    }
}


var isIE = (document.all) ? true : false;

var $ = function(id) {
    return "string" == typeof id ? document.getElementById(id) : id;
};

var Class = {
    create: function() {
        return function() { this.initialize.apply(this, arguments); }
    }
}

var Extend = function(destination, source) {
    for (var property in source) {
        destination[property] = source[property];
    }
}

var Bind = function(object, fun) {
    return function() {
        return fun.apply(object, arguments);
    }
}

var BindAsEventListener = function(object, fun) {
    var args = Array.prototype.slice.call(arguments).slice(2);
    return function(event) {
        return fun.apply(object, [event || window.event].concat(args));
    }
}

var CurrentStyle = function(element) {
    return element.currentStyle || document.defaultView.getComputedStyle(element, null);
}

function addEventHandler(oTarget, sEventType, fnHandler) {
    if (oTarget.addEventListener) {
        oTarget.addEventListener(sEventType, fnHandler, false);
    } else if (oTarget.attachEvent) {
        oTarget.attachEvent("on" + sEventType, fnHandler);
    } else {
        oTarget["on" + sEventType] = fnHandler;
    }
};

function removeEventHandler(oTarget, sEventType, fnHandler) {
    if (oTarget.removeEventListener) {
        oTarget.removeEventListener(sEventType, fnHandler, false);
    } else if (oTarget.detachEvent) {
        oTarget.detachEvent("on" + sEventType, fnHandler);
    } else {
        oTarget["on" + sEventType] = null;
    }
};



var Resize = Class.create();
Resize.prototype = {
    //���Ŷ���
    initialize: function(obj, options) {
        this._obj = $(obj); //���Ŷ���

        this._styleWidth = this._styleHeight = this._styleLeft = this._styleTop = 0; //��ʽ����
        this._sideRight = this._sideDown = this._sideLeft = this._sideUp = 0; //�������
        this._fixLeft = this._fixTop = 0; //��λ����
        this._scaleLeft = this._scaleTop = 0; //��λ����

        this._mxSet = function() { }; //��Χ���ó���
        this._mxRightWidth = this._mxDownHeight = this._mxUpHeight = this._mxLeftWidth = 0; //��Χ����
        this._mxScaleWidth = this._mxScaleHeight = 0; //������Χ����

        this._fun = function() { }; //����ִ�г���

        //��ȡ�߿����
        var _style = CurrentStyle(this._obj);
        this._borderX = (parseInt(_style.borderLeftWidth) || 0) + (parseInt(_style.borderRightWidth) || 0);
        this._borderY = (parseInt(_style.borderTopWidth) || 0) + (parseInt(_style.borderBottomWidth) || 0);
        //�¼�����(���ڰ��Ƴ��¼�)
        this._fR = BindAsEventListener(this, this.Resize);
        this._fS = Bind(this, this.Stop);

        this.SetOptions(options);
        //��Χ����
        this.Max = !!this.options.Max;
        this._mxContainer = $(this.options.mxContainer) || null;
        this.mxLeft = Math.round(this.options.mxLeft);
        this.mxRight = Math.round(this.options.mxRight);
        this.mxTop = Math.round(this.options.mxTop);
        this.mxBottom = Math.round(this.options.mxBottom);
        //��������
        this.Min = !!this.options.Min;
        this.minWidth = Math.round(this.options.minWidth);
        this.minHeight = Math.round(this.options.minHeight);
        //����������
        this.Scale = !!this.options.Scale;
        this.Ratio = Math.max(this.options.Ratio, 0);

        this.onResize = this.options.onResize;

        this._obj.style.position = "absolute";
        !this._mxContainer || CurrentStyle(this._mxContainer).position == "relative" || (this._mxContainer.style.position = "relative");
    },
    //����Ĭ������
    SetOptions: function(options) {
        this.options = {//Ĭ��ֵ
            Max: false, //�Ƿ����÷�Χ����(Ϊtrueʱ����mx��������)
            mxContainer: "", //ָ��������������
            mxLeft: 0, //�������
            mxRight: 9999, //�ұ�����
            mxTop: 0, //�ϱ�����
            mxBottom: 9999, //�±�����
            Min: false, //�Ƿ���С��������(Ϊtrueʱ����min��������)
            minWidth: 50, //��С����
            minHeight: 50, //��С�߶�
            Scale: false, //�Ƿ񰴱�������
            Ratio: 0, //���ű���(��/��)
            onResize: function() { } //����ʱִ��
        };
        Extend(this.options, options || {});
    },
    //���ô�������
    Set: function(resize, side) {
        var resize = $(resize), fun;
        if (!resize) return;
        //���ݷ�������
        switch (side.toLowerCase()) {
            case "up":
                fun = this.Up;
                break;
            case "down":
                fun = this.Down;
                break;
            case "left":
                fun = this.Left;
                break;
            case "right":
                fun = this.Right;
                break;
            case "left-up":
                fun = this.LeftUp;
                break;
            case "right-up":
                fun = this.RightUp;
                break;
            case "left-down":
                fun = this.LeftDown;
                break;
            case "right-down":
            default:
                fun = this.RightDown;
        };
        //���ô�������
        addEventHandler(resize, "mousedown", BindAsEventListener(this, this.Start, fun));
    },
    //׼������
    Start: function(e, fun, touch) {
        //��ֹð��(���Ϸ����ʱ����)
        e.stopPropagation ? e.stopPropagation() : (e.cancelBubble = true);
        //����ִ�г���
        this._fun = fun;
        //��ʽ����ֵ
        this._styleWidth = this._obj.clientWidth;
        this._styleHeight = this._obj.clientHeight;
        this._styleLeft = this._obj.offsetLeft;
        this._styleTop = this._obj.offsetTop;
        //�����߶�λ����
        this._sideLeft = e.clientX - this._styleWidth;
        this._sideRight = e.clientX + this._styleWidth;
        this._sideUp = e.clientY - this._styleHeight;
        this._sideDown = e.clientY + this._styleHeight;
        //top��left��λ����
        this._fixLeft = this._styleLeft + this._styleWidth;
        this._fixTop = this._styleTop + this._styleHeight;
        //���ű���
        if (this.Scale) {
            //���ñ���
            this.Ratio = Math.max(this.Ratio, 0) || this._styleWidth / this._styleHeight;
            //left��top�Ķ�λ����
            this._scaleLeft = this._styleLeft + this._styleWidth / 2;
            this._scaleTop = this._styleTop + this._styleHeight / 2;
        };
        //��Χ����
        if (this.Max) {
            //���÷�Χ����
            var mxLeft = this.mxLeft, mxRight = this.mxRight, mxTop = this.mxTop, mxBottom = this.mxBottom;
            //�����������������������Χ����
            if (!!this._mxContainer) {
                mxLeft = Math.max(mxLeft, 0);
                mxTop = Math.max(mxTop, 0);
                mxRight = Math.min(mxRight, this._mxContainer.clientWidth);
                mxBottom = Math.min(mxBottom, this._mxContainer.clientHeight);
            };
            //������Сֵ������
            mxRight = Math.max(mxRight, mxLeft + (this.Min ? this.minWidth : 0) + this._borderX);
            mxBottom = Math.max(mxBottom, mxTop + (this.Min ? this.minHeight : 0) + this._borderY);
            //����ת��ʱҪ������������д��function��ʽ
            this._mxSet = function() {
                this._mxRightWidth = mxRight - this._styleLeft - this._borderX;
                this._mxDownHeight = mxBottom - this._styleTop - this._borderY;
                this._mxUpHeight = Math.max(this._fixTop - mxTop, this.Min ? this.minHeight : 0);
                this._mxLeftWidth = Math.max(this._fixLeft - mxLeft, this.Min ? this.minWidth : 0);
            };
            this._mxSet();
            //�����ű����µķ�Χ����
            if (this.Scale) {
                this._mxScaleWidth = Math.min(this._scaleLeft - mxLeft, mxRight - this._scaleLeft - this._borderX) * 2;
                this._mxScaleHeight = Math.min(this._scaleTop - mxTop, mxBottom - this._scaleTop - this._borderY) * 2;
            };
        };
        //mousemoveʱ���� mouseupʱֹͣ
        addEventHandler(document, "mousemove", this._fR);
        addEventHandler(document, "mouseup", this._fS);
        if (isIE) {
            addEventHandler(this._obj, "losecapture", this._fS);
            this._obj.setCapture();
        } else {
            addEventHandler(window, "blur", this._fS);
            e.preventDefault();
        };
    },
    //����
    Resize: function(e) {
        //���ѡ��
        window.getSelection ? window.getSelection().removeAllRanges() : document.selection.empty();
        //ִ�����ų���
        this._fun(e);
        //������ʽ������������ڵ���0����ie����
        with (this._obj.style) {
            width = this._styleWidth + "px"; height = this._styleHeight + "px";
            top = this._styleTop + "px"; left = this._styleLeft + "px";
        }
        //���ӳ���
        this.onResize();
    },
    //���ų���
    //��
    Up: function(e) {
        this.RepairY(this._sideDown - e.clientY, this._mxUpHeight);
        this.RepairTop();
        this.TurnDown(this.Down);
    },
    //��
    Down: function(e) {
        this.RepairY(e.clientY - this._sideUp, this._mxDownHeight);
        this.TurnUp(this.Up);
    },
    //��
    Right: function(e) {
        this.RepairX(e.clientX - this._sideLeft, this._mxRightWidth);
        this.TurnLeft(this.Left);
    },
    //��
    Left: function(e) {
        this.RepairX(this._sideRight - e.clientX, this._mxLeftWidth);
        this.RepairLeft();
        this.TurnRight(this.Right);
    },
    //����
    RightDown: function(e) {
        this.RepairAngle(
		e.clientX - this._sideLeft, this._mxRightWidth,
		e.clientY - this._sideUp, this._mxDownHeight
	);
        this.TurnLeft(this.LeftDown) || this.Scale || this.TurnUp(this.RightUp);
    },
    //����
    RightUp: function(e) {
        this.RepairAngle(
		e.clientX - this._sideLeft, this._mxRightWidth,
		this._sideDown - e.clientY, this._mxUpHeight
	);
        this.RepairTop();
        this.TurnLeft(this.LeftUp) || this.Scale || this.TurnDown(this.RightDown);
    },
    //����
    LeftDown: function(e) {
        this.RepairAngle(
		this._sideRight - e.clientX, this._mxLeftWidth,
		e.clientY - this._sideUp, this._mxDownHeight
	);
        this.RepairLeft();
        this.TurnRight(this.RightDown) || this.Scale || this.TurnUp(this.LeftUp);
    },
    //����
    LeftUp: function(e) {
        this.RepairAngle(
		this._sideRight - e.clientX, this._mxLeftWidth,
		this._sideDown - e.clientY, this._mxUpHeight
	);
        this.RepairTop(); this.RepairLeft();
        this.TurnRight(this.RightUp) || this.Scale || this.TurnDown(this.LeftDown);
    },
    //��������
    //ˮƽ����
    RepairX: function(iWidth, mxWidth) {
        iWidth = this.RepairWidth(iWidth, mxWidth);
        if (this.Scale) {
            var iHeight = this.RepairScaleHeight(iWidth);
            if (this.Max && iHeight > this._mxScaleHeight) {
                iHeight = this._mxScaleHeight;
                iWidth = this.RepairScaleWidth(iHeight);
            } else if (this.Min && iHeight < this.minHeight) {
                var tWidth = this.RepairScaleWidth(this.minHeight);
                if (tWidth < mxWidth) { iHeight = this.minHeight; iWidth = tWidth; }
            }
            this._styleHeight = iHeight;
            this._styleTop = this._scaleTop - iHeight / 2;
        }
        this._styleWidth = iWidth;
    },
    //��ֱ����
    RepairY: function(iHeight, mxHeight) {
        iHeight = this.RepairHeight(iHeight, mxHeight);
        if (this.Scale) {
            var iWidth = this.RepairScaleWidth(iHeight);
            if (this.Max && iWidth > this._mxScaleWidth) {
                iWidth = this._mxScaleWidth;
                iHeight = this.RepairScaleHeight(iWidth);
            } else if (this.Min && iWidth < this.minWidth) {
                var tHeight = this.RepairScaleHeight(this.minWidth);
                if (tHeight < mxHeight) { iWidth = this.minWidth; iHeight = tHeight; }
            }
            this._styleWidth = iWidth;
            this._styleLeft = this._scaleLeft - iWidth / 2;
        }
        this._styleHeight = iHeight;
    },
    //�ԽǷ���
    RepairAngle: function(iWidth, mxWidth, iHeight, mxHeight) {
        iWidth = this.RepairWidth(iWidth, mxWidth);
        if (this.Scale) {
            iHeight = this.RepairScaleHeight(iWidth);
            if (this.Max && iHeight > mxHeight) {
                iHeight = mxHeight;
                iWidth = this.RepairScaleWidth(iHeight);
            } else if (this.Min && iHeight < this.minHeight) {
                var tWidth = this.RepairScaleWidth(this.minHeight);
                if (tWidth < mxWidth) { iHeight = this.minHeight; iWidth = tWidth; }
            }
        } else {
            iHeight = this.RepairHeight(iHeight, mxHeight);
        }
        this._styleWidth = iWidth;
        this._styleHeight = iHeight;
    },
    //top
    RepairTop: function() {
        this._styleTop = this._fixTop - this._styleHeight;
    },
    //left
    RepairLeft: function() {
        this._styleLeft = this._fixLeft - this._styleWidth;
    },
    //height
    RepairHeight: function(iHeight, mxHeight) {
        iHeight = Math.min(this.Max ? mxHeight : iHeight, iHeight);
        iHeight = Math.max(this.Min ? this.minHeight : iHeight, iHeight, 0);
        return iHeight;
    },
    //width
    RepairWidth: function(iWidth, mxWidth) {
        iWidth = Math.min(this.Max ? mxWidth : iWidth, iWidth);
        iWidth = Math.max(this.Min ? this.minWidth : iWidth, iWidth, 0);
        return iWidth;
    },
    //�����߶�
    RepairScaleHeight: function(iWidth) {
        return Math.max(Math.round((iWidth + this._borderX) / this.Ratio - this._borderY), 0);
    },
    //��������
    RepairScaleWidth: function(iHeight) {
        return Math.max(Math.round((iHeight + this._borderY) * this.Ratio - this._borderX), 0);
    },
    //ת�����
    //ת��
    TurnRight: function(fun) {
        if (!(this.Min || this._styleWidth)) {
            this._fun = fun;
            this._sideLeft = this._sideRight;
            this.Max && this._mxSet();
            return true;
        }
    },
    //ת��
    TurnLeft: function(fun) {
        if (!(this.Min || this._styleWidth)) {
            this._fun = fun;
            this._sideRight = this._sideLeft;
            this._fixLeft = this._styleLeft;
            this.Max && this._mxSet();
            return true;
        }
    },
    //ת��
    TurnUp: function(fun) {
        if (!(this.Min || this._styleHeight)) {
            this._fun = fun;
            this._sideDown = this._sideUp;
            this._fixTop = this._styleTop;
            this.Max && this._mxSet();
            return true;
        }
    },
    //ת��
    TurnDown: function(fun) {
        if (!(this.Min || this._styleHeight)) {
            this._fun = fun;
            this._sideUp = this._sideDown;
            this.Max && this._mxSet();
            return true;
        }
    },
    //ֹͣ����
    Stop: function() {
        removeEventHandler(document, "mousemove", this._fR);
        removeEventHandler(document, "mouseup", this._fS);
        if (isIE) {
            removeEventHandler(this._obj, "losecapture", this._fS);
            this._obj.releaseCapture();
        } else {
            removeEventHandler(window, "blur", this._fS);
        }
    }
};



var Drag = Class.create();
Drag.prototype = {
  //�ϷŶ���
  initialize: function(drag, options) {
	this.Drag = $(drag);//�ϷŶ���
	this._x = this._y = 0;//��¼�������ϷŶ����λ��
	this._marginLeft = this._marginTop = 0;//��¼margin
	//�¼�����(���ڰ��Ƴ��¼�)
	this._fM = BindAsEventListener(this, this.Move);
	this._fS = Bind(this, this.Stop);
	
	this.SetOptions(options);
	
	this.Limit = !!this.options.Limit;
	this.mxLeft = parseInt(this.options.mxLeft);
	this.mxRight = parseInt(this.options.mxRight);
	this.mxTop = parseInt(this.options.mxTop);
	this.mxBottom = parseInt(this.options.mxBottom);
	
	this.LockX = !!this.options.LockX;
	this.LockY = !!this.options.LockY;
	this.Lock = !!this.options.Lock;
	
	this.onStart = this.options.onStart;
	this.onMove = this.options.onMove;
	this.onStop = this.options.onStop;
	
	this._Handle = $(this.options.Handle) || this.Drag;
	this._mxContainer = $(this.options.mxContainer) || null;
	
	this.Drag.style.position = "absolute";
	//͸��
	if(isIE && !!this.options.Transparent){
		//����ϷŶ���
		with(this._Handle.appendChild(document.createElement("div")).style){
			width = height = "100%"; backgroundColor = "#fff"; filter = "alpha(opacity:0)"; fontSize = 0;
		}
	}
	//������Χ
	this.Repair();
	addEventHandler(this._Handle, "mousedown", BindAsEventListener(this, this.Start));
  },
  //����Ĭ������
  SetOptions: function(options) {
	this.options = {//Ĭ��ֵ
		Handle:			"",//���ô������󣨲�������ʹ���ϷŶ���
		Limit:			false,//�Ƿ����÷�Χ����(Ϊtrueʱ�����������,�����Ǹ���)
		mxLeft:			0,//�������
		mxRight:		9999,//�ұ�����
		mxTop:			0,//�ϱ�����
		mxBottom:		9999,//�±�����
		mxContainer:	"",//ָ��������������
		LockX:			false,//�Ƿ�����ˮƽ�����Ϸ�
		LockY:			false,//�Ƿ�������ֱ�����Ϸ�
		Lock:			false,//�Ƿ�����
		Transparent:	false,//�Ƿ�͸��
		onStart:		function(){},//��ʼ�ƶ�ʱִ��
		onMove:			function(){},//�ƶ�ʱִ��
		onStop:			function(){}//�����ƶ�ʱִ��
	};
	Extend(this.options, options || {});
  },
  //׼���϶�
  Start: function(oEvent) {
	if(this.Lock){ return; }
	this.Repair();
	//��¼�������ϷŶ����λ��
	this._x = oEvent.clientX - this.Drag.offsetLeft;
	this._y = oEvent.clientY - this.Drag.offsetTop;
	//��¼margin
	this._marginLeft = parseInt(CurrentStyle(this.Drag).marginLeft) || 0;
	this._marginTop = parseInt(CurrentStyle(this.Drag).marginTop) || 0;
	//mousemoveʱ�ƶ� mouseupʱֹͣ
	addEventHandler(document, "mousemove", this._fM);
	addEventHandler(document, "mouseup", this._fS);
	if(isIE){
		//���㶪ʧ
		addEventHandler(this._Handle, "losecapture", this._fS);
		//������겶��
		this._Handle.setCapture();
	}else{
		//���㶪ʧ
		addEventHandler(window, "blur", this._fS);
		//��ֹĬ�϶���
		oEvent.preventDefault();
	};
	//���ӳ���
	this.onStart();
  },
  //������Χ
  Repair: function() {
	if(this.Limit){
		//��������Χ����
		this.mxRight = Math.max(this.mxRight, this.mxLeft + this.Drag.offsetWidth);
		this.mxBottom = Math.max(this.mxBottom, this.mxTop + this.Drag.offsetHeight);
		//�����������������positionΪrelative��absolute����Ի���Զ�λ�����ڻ�ȡoffset֮ǰ����
		!this._mxContainer || CurrentStyle(this._mxContainer).position == "relative" || CurrentStyle(this._mxContainer).position == "absolute" || (this._mxContainer.style.position = "relative");
	}
  },
  //�϶�
  Move: function(oEvent) {
	//�ж��Ƿ�����
	if(this.Lock){ this.Stop(); return; };
	//���ѡ��
	window.getSelection ? window.getSelection().removeAllRanges() : document.selection.empty();
	//�����ƶ�����
	var iLeft = oEvent.clientX - this._x, iTop = oEvent.clientY - this._y;
	//���÷�Χ����
	if(this.Limit){
		//���÷�Χ����
		var mxLeft = this.mxLeft, mxRight = this.mxRight, mxTop = this.mxTop, mxBottom = this.mxBottom;
		//�����������������������Χ����
		if(!!this._mxContainer){
			mxLeft = Math.max(mxLeft, 0);
			mxTop = Math.max(mxTop, 0);
			mxRight = Math.min(mxRight, this._mxContainer.clientWidth);
			mxBottom = Math.min(mxBottom, this._mxContainer.clientHeight);
		};
		//�����ƶ�����
		iLeft = Math.max(Math.min(iLeft, mxRight - this.Drag.offsetWidth), mxLeft);
		iTop = Math.max(Math.min(iTop, mxBottom - this.Drag.offsetHeight), mxTop);
	}
	//����λ�ã�������margin
	if(!this.LockX){ this.Drag.style.left = iLeft - this._marginLeft + "px"; }
	if(!this.LockY){ this.Drag.style.top = iTop - this._marginTop + "px"; }
	//���ӳ���
	this.onMove();
  },
  //ֹͣ�϶�
  Stop: function() {
	//�Ƴ��¼�
	removeEventHandler(document, "mousemove", this._fM);
	removeEventHandler(document, "mouseup", this._fS);
	if(isIE){
		removeEventHandler(this._Handle, "losecapture", this._fS);
		this._Handle.releaseCapture();
	}else{
		removeEventHandler(window, "blur", this._fS);
	};
	//���ӳ���
	this.onStop();
  }
};