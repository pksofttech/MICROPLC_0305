# LD FORMAT copy Form LDMICRO#
HARDWARE
ArUnitControl 32IO
IO LIST
Xhi_lavel at X00
Xlow_lavel at X01
Xstart_lavel at X02
Ylamp_err at Y00
YPump1 at Y01
YPump2 at Y02
END
PROGRAM
RUNG
	CONTACTS Xlow_lavel 0 0 0
	PARALLEL
		CONTACTS Xstart_lavel 0 0 0
		CONTACTS Ractive_action 0 0 0
	END
	COIL Ractive_action 0 0 0 0
END
RUNG
	CONTACTS Xlow_lavel 1 0 0
	PARALLEL
		COIL Rpump_err1 0 0 1 0
		COIL Rpump_err2 0 0 1 0
	END
END
RUNG
	PARALLEL
		CONTACTS Xhi_lavel 0 0 0
		CONTACTS Rpump_err1 0 0 0
		CONTACTS Rpump_err2 0 0 0
	END
	COIL Rhi_lavel 0 0 0 0
END
RUNG
	CONTACTS RPump1 1 0 0
	CONTACTS RPump2 1 0 0
	COIL Claeching 0 0 0 1 2 1
END
RUNG
	CONTACTS Ractive_action 0 0 0
	PARALLEL
		CONTACTS Claeching 0 1 0 2 1
		CONTACTS Rhi_lavel 0 0 0
		CONTACTS RPump1 0 0 0
	END
	COIL RPump1 0 0 0 0
END
RUNG
	CONTACTS Ractive_action 0 0 0
	PARALLEL
		CONTACTS Claeching 1 1 0 2 1
		CONTACTS Rhi_lavel 0 0 0
		CONTACTS RPump2 0 0 0
	END
	COIL RPump2 0 0 0 0
END
RUNG
	PARALLEL
		CONTACTS Rpump_err1 0 0 0
		CONTACTS Rpump_err2 0 0 0
	END
	PARALLEL
		SERIES
			CONTACTS Rlamp_err 1 0 0
			TPC Ter_rpluse 100 100
		END
		CONTACTS Rlamp_err 0 0 0
	END
	COIL Ylamp_err 0 0 0 0
END
RUNG
	PARALLEL
		CONTACTS Rpump_err1 0 0 0
		CONTACTS Rpump_err2 0 0 0
	END
	TON Tofferr 3000
	COIL Rlamp_err 0 0 0 0
END
RUNG
	CONTACTS RPump1 0 0 0
	TON Tdelay_check1 100
	CONTACTS YPump1 1 0 0
	COIL Rpump_err1 0 1 0 0
END
RUNG
	CONTACTS RPump2 0 0 0
	TON Tdelay_check2 100
	CONTACTS YPump2 1 0 0
	COIL Rpump_err2 0 1 0 0
END
RUNG
	CONTACTS RPump1 0 0 0
	CONTACTS Rpump_err1 1 0 0
	COIL YPump1 0 0 0 0
END
RUNG
	CONTACTS RPump2 0 0 0
	CONTACTS Rpump_err2 1 0 0
	COIL YPump2 0 0 0 0
END
