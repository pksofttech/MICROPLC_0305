# LD FORMAT copy Form LDMICRO#
HARDWARE
Arduino UNOR3
IO LIST
Xlimit_close at D11
Xlimit_open at D10
Xlimit_open_f at D9
Xpb_close at D7
Xpb_open at D6
Xpb_open_f at D5
Xpb_stop at D8
Yclose_status at D13
Yopen_status at D12
END
PROGRAM
RUNG
	CONTACTS RStop 1 0 0
	CONTACTS Xlimit_open_f 1 0 0
	CONTACTS RClose 1 0 0
	PARALLEL
		SERIES
			CONTACTS Xpb_open_f 0 0 0
			TON Tdelay_open_f 500
		END
		CONTACTS ROpen_f 0 0 0
	END
	COIL ROpen_f 0 0 0 0
END
RUNG
	CONTACTS RStop 1 0 0
	CONTACTS Xlimit_open 1 0 0
	CONTACTS ROpen_f 1 0 0
	CONTACTS RClose 1 0 0
	PARALLEL
		SERIES
			CONTACTS Xpb_open 0 0 0
			TON Tdelay_open 500
		END
		CONTACTS ROpen 0 0 0
	END
	COIL ROpen 0 0 0 0
END
RUNG
	CONTACTS RStop 1 0 0
	CONTACTS Xlimit_close 1 0 0
	CONTACTS ROpen 1 0 0
	CONTACTS ROpen_f 1 0 0
	PARALLEL
		SERIES
			CONTACTS Xpb_close 0 0 0
			TON Tdelay_close 500
		END
		CONTACTS RClose 0 0 0
	END
	COIL RClose 0 0 0 0
END
RUNG
	CONTACTS Xpb_stop 0 0 0
	TON Tdelay_stop 100
	COIL RStop 0 0 0 0
END
RUNG
	PARALLEL
		CONTACTS ROpen 0 0 0
		CONTACTS ROpen_f 0 0 0
	END
	CONTACTS Yclose_status 1 0 0
	COIL Yopen_status 0 0 0 0
END
RUNG
	CONTACTS RClose 0 0 0
	CONTACTS Yopen_status 1 0 0
	COIL Yclose_status 0 0 0 0
END
